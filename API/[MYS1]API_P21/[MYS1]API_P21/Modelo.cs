using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimioAPI;
using SimioAPI.Extensions;

using SimioAPI.Graphics;
using Simio;
using Simio.SimioEnums;

namespace _MYS1_API_P21
{
    class Modelo
    {
        private ISimioProject proyectoApi;
        private string rutabase = "[MYS1]ModeloBase_P21.spfx";
        private string rutafinal = "[MYS1]Tienda2_P21.spfx";
        private string[] warnings;
        private IModel model;
        private IIntelligentObjects intelligentObjects;
        private ILengthUnit lengthunits;

        public Modelo() {
            proyectoApi = SimioProjectFactory.LoadProject(rutabase, out warnings);
            model = proyectoApi.Models[1];
            intelligentObjects = model.Facility.IntelligentObjects;    
        }
        public void createModel()
        {
            CreateMap();
            SimioProjectFactory.SaveProject(proyectoApi, rutafinal, out warnings);
        }
        public void CreateMap() {

            /*********ENTRADA CLIENTE****/
            createSource(-9,0);
            updateName("Source1", "EntradaCliente");

            /***********SALIDA CLIENTE****/
            createSink(-9, 3);
            updateName("Sink1", "SalidaCliente");

            /**********BARRA LATERAL IZQUIERDA*****/
            createServer(2,-7);
            updateName("Server1", "BarraLateralIzquierda");

            /**********CAJA ******/
            createServer(8,0);
            updateName("Server1", "Caja");

            /**********BODEGA*****/
            createSource(12, -6);
            updateName("Source1", "Bodega");


            /**********ENTREGA*****/
            createCombiner(18, -1);
            updateName("Combiner1", "Entrega");

            /**********BARRA LATERAL DERECHA*****/
            createServer(37, -7);
            updateName("Server1", "BarraLateralDerecha");

            /**********BARRA FRONTAL*****/
            createServer(31, 1);
            updateName("Server1", "BarraFrontal");


            /**********CONJUNTO MESAS IZQUERDAAAAA*****/

            createServer(-9, 15);
            updateName("Server1", "Mesa1");

            createServer(0, 9);
            updateName("Server1", "Mesa2");

            createServer(9, 15);
            updateName("Server1", "Mesa3");

            createServer(0, 20);
            updateName("Server1", "Mesa4");

            createServer(0, 15);
            updateName("Server1", "Mesa9");


            /*****************CONJUNTO MESAS DERECHA******/

            createServer(21, 15);
            updateName("Server1", "Mesa5");

            createServer(30, 9);
            updateName("Server1", "Mesa6");

            createServer(39, 15);
            updateName("Server1", "Mesa7");

            createServer(30, 20);
            updateName("Server1", "Mesa8");

            createServer(30, 15);
            updateName("Server1", "Mesa10");

            /********************TRANFER DE ENTRADA ***********/

            createTransferNode(17, 6);
            updateName("TransferNode1", "Entrada");

            createTransferNode(11, 10);
            updateName("TransferNode1", "Entrada1_8");

            createTransferNode(21, 10);
            updateName("TransferNode1", "Entrada9_10");


            /********************TRANFER DE SALIDA ***********/

            createTransferNode(17, 10);
            updateName("TransferNode1", "Salida");


            /****************CONEXIONES CON SUS PROPIEDADES********/

            /**ENTRADA A CAJA ***/
            createPath(getNodo("EntradaCliente", 0), getNodo("Caja", 0));
            updateName("Path1", "Entrada_Caja");
            updateProperty("Entrada_Caja", "DrawnToScale", "False");
            updateProperty("Entrada_Caja", "LogicalLength", "8");

            /**CAJA A ENTREGA****/

            createPath(getNodo("Caja", 1), getNodo("Entrega", 1));
            updateName("Path1", "Caja_Entrega");
            updateProperty("Caja_Entrega", "DrawnToScale", "False");
            updateProperty("Caja_Entrega", "LogicalLength", "6");

            /**BODEGA A ENTREGA***/
            createPath(getNodo("Bodega", 0), getNodo("Entrega", 0));
            updateName("Path1", "Bodega_Entrega");

            /**ENTREGA A BARRA FRONTAL**/
            createPath(getNodo("Entrega", 0), getNodo("BarraFrontal", 0));
            updateName("Path1", "Entrega_BarraFrontal");
            updateProperty("Entrega_BarraFrontal", "DrawnToScale", "False");
            updateProperty("Entrega_BarraFrontal", "LogicalLength", "5");

            /**ENTREGA A BARRA LATERAL**/
            createPath(getNodo("Entrega", 0), getNodo("BarraFrontal", 0));
            updateName("Path1", "Entrega_BarraFrontal");
            updateProperty("Entrega_BarraFrontal", "DrawnToScale", "False");
            updateProperty("Entrega_BarraFrontal", "LogicalLength", "5");



        }

   

        //-------------------Objetos-------------------//

        public void createSource(int x, int y)
        {
            this.createObject("Source", x, y);

        }
        public void createServer(int x, int y)
        {
            this.createObject("Server", x, y);
        }

        public void createSink(int x, int y)
        {
            this.createObject("Sink", x, y);
        }

        public void createCombiner(int x, int y ) {

            this.createObject("Combiner", x, y);
        }
        public void createTransferNode(int x, int y)
        {
            this.createObject("TransferNode", x, y);
        }

        public void createPath(INodeObject nodo1, INodeObject nodo2)
        {
            this.createLink("Path", nodo1, nodo2);

        }
        
        public void createTimePath(INodeObject nodo1, INodeObject nodo2)
        {
            this.createLink("TimePath", nodo1, nodo2);
        }
        
        public void createConveyor(INodeObject nodo1, INodeObject nodo2)
        {
            this.createLink("Conveyor", nodo1, nodo2);
        }

        public void createObject(String type, int x, int y)
        {
            intelligentObjects.CreateObject(type, new FacilityLocation(x, 0, y));
        }

        public void createLink(String type, INodeObject nodo1, INodeObject nodo2)
        {
            intelligentObjects.CreateLink(type, nodo1, nodo2, null);

        }

        //------------------------------------- Modificar propiedades --------------------------------//
        public void updateProperty(String name, String property, String value)
        {
            model.Facility.IntelligentObjects[name].Properties[property].Value = value;
        }

        //--------------------------------------- Modificar nombre  -----------------------------------//
        public void updateName(String oldName, String newName)
        {
            model.Facility.IntelligentObjects[oldName].ObjectName = newName;
        }

        //---------------------------------------- Obtener Nodo ----------------------------------------//
        public INodeObject getNodo(String name, int nodo)
        {
            return ((IFixedObject)model.Facility.IntelligentObjects[name]).Nodes[nodo];
        }

        //---------------------------------- Obtener Nodo Basicos --------------------------------------//
        public INodeObject getNodobasico(String name)
        {
            return (INodeObject)model.Facility.IntelligentObjects[name];
        }

    }
}
