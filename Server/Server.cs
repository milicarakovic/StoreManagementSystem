using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private Socket osluskujuciSoket;
        private List<Obrada> klijenti = new List<Obrada>();
        public bool PokreniServer()
        {
            try
            {
                osluskujuciSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                osluskujuciSoket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9090));
                osluskujuciSoket.Listen(4);
                return true;
            }
            catch (SocketException)
            {
                return false;
            }
        }

        public void Osluskuj()
        {
            try
            {
                bool kraj = false;
                while (!kraj)
                {
                    Socket klijentskiSoket = osluskujuciSoket.Accept();
                    Obrada obrada = new Obrada(klijentskiSoket);
                    klijenti.Add(obrada);
                    Thread nitKlijenta = new Thread(obrada.ObradaZahteva);
                    nitKlijenta.Start();
                }
            }
            catch (SocketException e)
            {
                Debug.WriteLine(">>>" + e.Message);
            }
        }

        public bool ZaustaviServer()
        {
            try
            {
               osluskujuciSoket.Close();
                foreach(Obrada o in klijenti)
                {
                    o.Zaustavi();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
