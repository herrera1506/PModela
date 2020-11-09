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
        public void CreateMap()
        {

            /*********ENTRADA CLIENTE****/
            createSource(-9, 0);
            updateName("Source1", "EntradaCliente");
            updateProperty("EntradaCliente", "InterarrivalTime", "Random.Uniform( 1.2 , 1.8 )");

            /***********SALIDA CLIENTE****/
            createSink(-9, 3);
            updateName("Sink1", "SalidaCliente");


            /**********CAJA ******/
            createServer(8, 0);
            updateName("Server1", "Caja");
            updateProperty("Caja", "ProcessingTime", "Random.Uniform( 0.58 , 1.75)");


            /**********BODEGA*****/
            createSource(12, -6);
            updateName("Source1", "Bodega");
            updateProperty("Bodega", "InterarrivalTime", "Random.Uniform( 0.01 , 0.014)");


            /**********ENTREGA*****/
            createCombiner(18, -1);
            updateName("Combiner1", "Entrega");
            updateProperty("Output@Entrega", "OutboundLinkRule", "ByLinkWeight");
            updateProperty("Entrega", "BatchQuantity", "3");

            /**********BARRA LATERAL DERECHA*****/
            createServer(37, -7);
            updateName("Server1", "BarraLateralDerecha");
            updateProperty("BarraLateralDerecha", "InitialCapacity", "8");
            updateProperty("BarraLateralDerecha", "ProcessingTime", "Random.Triangular(3,5,8)");

            /**********BARRA FRONTAL*****/
            createServer(31, 1);
            updateName("Server1", "BarraFrontal");
            updateProperty("BarraFrontal", "InitialCapacity", "4");
            updateProperty("BarraFrontal", "ProcessingTime", "Random.Triangular(3,5,8)");


            /**********CONJUNTO MESAS IZQUERDAAAAA*****/

            createServer(-9, 15);
            updateName("Server1", "Mesa1");
            updateProperty("Mesa1", "InitialCapacity", "3");
            updateProperty("Mesa1", "ProcessingTime", "Random.Triangular(8,16,24)");
            updateProperty("Mesa1", "InputBufferCapacity", "0");
            updateProperty("Mesa1", "InputBufferBalkDecisionType", "Probabilistic");
            updateProperty("Mesa1", "InputBufferBalkConditionOrProbability", "0.12");
            updateProperty("Mesa1", "InputBufferBalkNodeName", "Input@Mesa4");


            createServer(0, 9);
            updateName("Server1", "Mesa2");
            updateProperty("Mesa2", "InitialCapacity", "3");
            updateProperty("Mesa2", "ProcessingTime", "Random.Triangular(8,16,24)");
            updateProperty("Mesa2", "InputBufferCapacity", "0");
            updateProperty("Mesa2", "InputBufferBalkDecisionType", "Probabilistic");
            updateProperty("Mesa2", "InputBufferBalkConditionOrProbability", "0.12");
            updateProperty("Mesa2", "InputBufferBalkNodeName", "Input@Mesa1");

            createServer(9, 15);
            updateName("Server1", "Mesa3");
            updateProperty("Mesa3", "InitialCapacity", "3");
            updateProperty("Mesa3", "ProcessingTime", "Random.Triangular(8,16,24)");
            updateProperty("Mesa3", "InputBufferCapacity", "0");
            updateProperty("Mesa3", "InputBufferBalkDecisionType", "Probabilistic");
            updateProperty("Mesa3", "InputBufferBalkConditionOrProbability", "0.12");
            updateProperty("Mesa3", "InputBufferBalkNodeName", "Input@Mesa2");

            createServer(0, 20);
            updateName("Server1", "Mesa4");
            updateProperty("Mesa4", "InitialCapacity", "3");
            updateProperty("Mesa4", "ProcessingTime", "Random.Triangular(8,16,24)");
            updateProperty("Mesa4", "InputBufferCapacity", "0");
            updateProperty("Mesa4", "InputBufferBalkDecisionType", "Probabilistic");
            updateProperty("Mesa4", "InputBufferBalkConditionOrProbability", "0.12");
            updateProperty("Mesa4", "InputBufferBalkNodeName", "Input@Mesa3");

            createServer(0, 15);
            updateName("Server1", "Mesa9");
            updateProperty("Mesa9", "InitialCapacity", "5");
            updateProperty("Mesa9", "ProcessingTime", "Random.Triangular(8,16,24)");
            updateProperty("Mesa1", "InputBufferCapacity", "0");
            //updateProperty("Mesa1", "InputBufferBalkDecisionType", "Probabilistic");
            updateProperty("Mesa1", "InputBufferBalkConditionOrProbability", "0.12");


            /*****************CONJUNTO MESAS DERECHA******/

            createServer(21, 15);
            updateName("Server1", "Mesa5");
            updateProperty("Mesa5", "InitialCapacity", "3");
            updateProperty("Mesa5", "ProcessingTime", "Random.Triangular(8,16,24)");
            updateProperty("Mesa5", "InputBufferCapacity", "0");
            updateProperty("Mesa5", "InputBufferBalkDecisionType", "Probabilistic");
            updateProperty("Mesa5", "InputBufferBalkConditionOrProbability", "0.12");
            updateProperty("Mesa5", "InputBufferBalkNodeName", "Input@Mesa8");

            createServer(30, 9);
            updateName("Server1", "Mesa6");
            updateProperty("Mesa6", "InitialCapacity", "3");
            updateProperty("Mesa6", "ProcessingTime", "Random.Triangular(8,16,24)");
            updateProperty("Mesa6", "InputBufferCapacity", "0");
            updateProperty("Mesa6", "InputBufferBalkDecisionType", "Probabilistic");
            updateProperty("Mesa6", "InputBufferBalkConditionOrProbability", "0.12");
            updateProperty("Mesa6", "InputBufferBalkNodeName", "Input@Mesa5");

            createServer(39, 15);
            updateName("Server1", "Mesa7");
            updateProperty("Mesa7", "InitialCapacity", "3");
            updateProperty("Mesa7", "ProcessingTime", "Random.Triangular(8,16,24)");
            updateProperty("Mesa7", "InputBufferCapacity", "0");
            updateProperty("Mesa7", "InputBufferBalkDecisionType", "Probabilistic");
            updateProperty("Mesa7", "InputBufferBalkConditionOrProbability", "0.12");
            updateProperty("Mesa7", "InputBufferBalkNodeName", "Input@Mesa6");

            createServer(30, 20);
            updateName("Server1", "Mesa8");
            updateProperty("Mesa8", "InitialCapacity", "3");
            updateProperty("Mesa8", "ProcessingTime", "Random.Triangular(8,16,24)");
            updateProperty("Mesa8", "InputBufferCapacity", "0");
            updateProperty("Mesa8", "InputBufferBalkDecisionType", "Probabilistic");
            updateProperty("Mesa8", "InputBufferBalkConditionOrProbability", "0.12");
            updateProperty("Mesa8", "InputBufferBalkNodeName", "Input@Mesa7");

            createServer(30, 15);
            updateName("Server1", "Mesa10");
            updateProperty("Mesa10", "InitialCapacity", "5");
            updateProperty("Mesa10", "ProcessingTime", "Random.Triangular(8,16,24)");
            updateProperty("Mesa10", "InputBufferCapacity", "0");
           // updateProperty("Mesa10", "InputBufferBalkDecisionType", "Probabilistic");
            //updateProperty("Mesa10", "InputBufferBalkConditionOrProbability", "0.12");

            /********************TRANFER DE ENTRADA ***********/


            createTransferNode(10, 8);
            updateName("TransferNode1", "Entrada1_8");

            createTransferNode(21, 8);
            updateName("TransferNode1", "Entrada9_10");


            createTransferNode(19, 3);
            updateName("TransferNode1", "SalidaSalida");

            /********************TRANFER DE SALIDA ***********/

            createTransferNode(16, 20);
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

            /**ENTREGA A BARRA FRONTAL * */
            createPath(getNodo("Entrega", 2), getNodo("BarraFrontal", 0));
            updateName("Path1", "Entrega_BarraFrontal");
            updateProperty("Entrega_BarraFrontal", "DrawnToScale", "False");
            updateProperty("Entrega_BarraFrontal", "LogicalLength", "5");
            updateProperty("Entrega_BarraFrontal", "SelectionWeight", "0.07");

            /**ENTREGA A BARRA LATERAL**/
            createPath(getNodo("Entrega", 2), getNodo("BarraLateralDerecha", 0));
            updateName("Path1", "Entrega_BarraLateral");
            updateProperty("Entrega_BarraLateral", "DrawnToScale", "False");
            updateProperty("Entrega_BarraLateral", "LogicalLength", "10");
            updateProperty("Entrega_BarraLateral", "SelectionWeight", "0.10");

            /**ENTREGA A MESA DE 1 A 8***/

            createTimePath(getNodo("Entrega", 2), getNodobasico("Entrada1_8"));
            updateName("TimePath1", "Entrega_Mesa1_8");
            updateProperty("Entrega_Mesa1_8", "TravelTime", "0.1166"); //7 segundos
            updateProperty("Entrega_Mesa1_8", "SelectionWeight", "0.25");

            //**ENTREGA A MESA 9 Y 10**/

            createTimePath(getNodo("Entrega", 2), getNodobasico("Entrada9_10"));
            updateName("TimePath1", "Entrega_Entrada9_10");
            updateProperty("Entrega_Entrada9_10", "TravelTime", "0.166"); //10 segundos
            updateProperty("Entrega_Entrada9_10", "SelectionWeight", "0.08");


            /***ENTREGA A SALIDA DE LA TIENDA ***/
            createTimePath(getNodo("Entrega", 2), getNodobasico("SalidaSalida"));
            updateName("TimePath1", "Entrega_Salida");
            updateProperty("Entrega_Salida", "TravelTime", "0.25"); //15 segundos
            updateProperty("Entrega_Salida", "SelectionWeight", "0.50");

            createTimePath(getNodobasico("SalidaSalida"), getNodo("SalidaCliente", 0));
            updateName("TimePath1", "Entrega_SalidaSalida");

            /***CUALQUIER MESA A SALIDA ***/
            createTimePath(getNodobasico("Salida"), getNodobasico("SalidaSalida"));
            updateName("TimePath1", "Salida_SalidaCliente");
            updateProperty("Salida_SalidaCliente", "TravelTime", "0.4166"); //25 segundos


            /**********ENTRE MESAS*******/
            /***ENTRADA***/

            createPath(getNodo("Mesa3", 1), getNodo("Mesa2", 0));
            updateName("Path1", "Mesa3_Mesa2");
            //updateProperty("Mesa3_Mesa2", "SelectionWeight", "0.125");

            createPath(getNodo("Mesa2", 1), getNodo("Mesa1", 0));
            updateName("Path1", "Mesa2_Mesa1");
            //updateProperty("Mesa2_Mesa1", "SelectionWeight", "0.125");

            createPath(getNodo("Mesa2", 1), getNodo("Mesa1", 0));
            updateName("Path1", "Mesa2_Mesa1");
            //updateProperty("Mesa2_Mesa1", "SelectionWeight", "0.125");

            createPath(getNodo("Mesa1", 1), getNodo("Mesa4", 0));
            updateName("Path1", "Mesa1_Mesa4");

            createPath(getNodo("Mesa4", 1), getNodo("Mesa3", 0));
            updateName("Path1", "Mesa4_Mesa3");

            createPath(getNodo("Mesa4", 1), getNodo("Mesa3", 0));
            updateName("Path1", "Mesa4_Mesa3");

            createPath(getNodo("Mesa6", 1), getNodo("Mesa5", 0));
            updateName("Path1", "Mesa6_Mesa5");

            createPath(getNodo("Mesa5", 1), getNodo("Mesa8", 0));
            updateName("Path1", "Mesa5_Mesa8");

            createPath(getNodo("Mesa8", 1), getNodo("Mesa7", 0));
            updateName("Path1", "Mesa8_Mesa7");

            createPath(getNodo("Mesa7", 1), getNodo("Mesa6", 0));
            updateName("Path1", "Mesa7_Mesa6");



            //createPath(getNodo("Mesa2", 1), getNodo("SalidaCliente", 0));
            //updateName("Path1", "Mesa2_SalidaCliente");

            createTimePath(getNodo("Mesa2",1), getNodo("SalidaCliente",0));
            updateName("TimePath1", "Salida_SalidaCliente");
            updateProperty("Salida_SalidaCliente", "TravelTime", "0.4166"); //25 segundos

            createPath(getNodo("Mesa6", 1), getNodobasico("Salida"));
            updateName("Path1", "Mesa6_Salida");

            createTimePath(getNodo("Mesa6", 1), getNodobasico("SalidaSalida"));
            updateName("TimePath1", "SalidaSalida_SalidaCliente");
            updateProperty("SalidaSalida_SalidaCliente", "TravelTime", "0.4166"); //25 segundos


            createPath(getNodobasico("Entrada1_8"), getNodo("Mesa3", 0));
            updateName("Path1", "Entrada1_8_Mesa1");

            createPath(getNodobasico("Entrada1_8"), getNodo("Mesa6", 0));
            updateName("Path1", "Entrada1_8_Mesa6");



            createPath(getNodobasico("Entrada9_10"), getNodo("Mesa9", 0));
            updateName("Path1", "Entrada9_10_Mesa9");
            updateProperty("Entrada9_10_Mesa9", "SelectionWeight", "0.5");


            createPath(getNodobasico("Entrada9_10"), getNodo("Mesa10", 0));
            updateName("Path1", "Entrada9_10_Mesa10");
            updateProperty("Entrada9_10_Mesa10", "SelectionWeight", "0.5");


            createPath(getNodo("Mesa9", 1), getNodobasico("Salida"));
            updateName("Path1", "Mesa9_Salida");

            createPath(getNodo("Mesa10", 1), getNodobasico("Salida"));
            updateName("Path1", "Mesa10_Salida");



            //updateProperty("Entrada1_8_Mesa1", "SelectionWeight", "0.125");


            /*
            createPath(getNodobasico("Entrada1_8"), getNodo("Mesa1", 0));
            updateName("Path1", "Entrada1_8_Mesa1");
            updateProperty("Entrada1_8_Mesa1", "SelectionWeight", "0.125");
            

            createPath(getNodobasico("Entrada1_8"), getNodo("Mesa2", 0));
            updateName("Path1", "Entrada1_8_Mesa2");
            updateProperty("Entrada1_8_Mesa2", "SelectionWeight", "0.125");

            createPath(getNodobasico("Entrada1_8"), getNodo("Mesa3", 0));
            updateName("Path1", "Entrada1_8_Mesa3");
            updateProperty("Entrada1_8_Mesa3", "SelectionWeight", "0.125");

            createPath(getNodobasico("Entrada1_8"), getNodo("Mesa4", 0));
            updateName("Path1", "Entrada1_8_Mesa4");
            updateProperty("Entrada1_8_Mesa4", "SelectionWeight", "0.125");

            createPath(getNodobasico("Entrada1_8"), getNodo("Mesa5", 0));
            updateName("Path1", "Entrada1_8_Mesa5");
            updateProperty("Entrada1_8_Mesa5", "SelectionWeight", "0.125");

            createPath(getNodobasico("Entrada1_8"), getNodo("Mesa6", 0));
            updateName("Path1", "Entrada1_8_Mesa6");
            updateProperty("Entrada1_8_Mesa6", "SelectionWeight", "0.125");

            createPath(getNodobasico("Entrada1_8"), getNodo("Mesa7", 0));
            updateName("Path1", "Entrada1_8_Mesa7");
            updateProperty("Entrada1_8_Mesa7", "SelectionWeight", "0.125");

            createPath(getNodobasico("Entrada1_8"), getNodo("Mesa8", 0));
            updateName("Path1", "Entrada1_8_Mesa8");
            updateProperty("Entrada1_8_Mesa8", "SelectionWeight", "0.125");
            */
            /****SALIDA*****/
            /*
            createPath(getNodo("Mesa1", 1), getNodobasico("Salida"));
            updateName("Path1", "Mesa1_Salida");


            createPath(getNodo("Mesa2", 1), getNodobasico("Salida"));
            updateName("Path1", "Mesa1_Salida");

            createPath(getNodo("Mesa3", 1), getNodobasico("Salida"));
            updateName("Path1", "Mesa3_Salida");

            createPath(getNodo("Mesa4", 1), getNodobasico("Salida"));
            updateName("Path1", "Mesa4_Salida");

            createPath(getNodo("Mesa5", 1), getNodobasico("Salida"));
            updateName("Path1", "Mesa5_Salida");

            createPath(getNodo("Mesa6", 1), getNodobasico("Salida"));
            updateName("Path1", "Mesa6_Salida");

            createPath(getNodo("Mesa7", 1), getNodobasico("Salida"));
            updateName("Path1", "Mesa7_Salida");

            createPath(getNodo("Mesa8", 1), getNodobasico("Salida"));
            updateName("Path1", "Mesa8_Salida");
            */




            /***ENTRADA****/
            /*
            createPath(getNodobasico("Entrada9_10"), getNodo("Mesa9", 0));
            updateName("Path1", "Entrada9_10_Mesa9");
            updateProperty("Entrada9_10_Mesa9", "SelectionWeight", "0.5");


            createPath(getNodobasico("Entrada9_10"), getNodo("Mesa10", 0));
            updateName("Path1", "Entrada9_10_Mesa10");
            updateProperty("Entrada9_10_Mesa10", "SelectionWeight", "0.5");

            /***SALIDAAAA***/
            /*
            createPath(getNodo("Mesa9", 1), getNodobasico("Salida"));
            updateName("Path1", "Mesa9_Salida");

            createPath(getNodo("Mesa10", 1), getNodobasico("Salida"));
            updateName("Path1", "Mesa10_Salida");
            */
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
