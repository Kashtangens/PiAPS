using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nwc.XmlRpc;

namespace Lab4Client
{
    class RpcClientClass
    {
        string host = "";

        public RpcClientClass(string host)
        {
            this.host = host;
        }

        public ArrayList MatrixTransform(ArrayList arr, int size)
        {
            // Отправка
            XmlRpcRequest client = new XmlRpcRequest();
            client.MethodName = "server.MatrixTransform";
            client.Params.Add(arr);
            client.Params.Add(size);
            XmlRpcResponse responce = client.Send(host);
            // Обработка ответа от сервера
            if (responce.IsFault)
            {
                return null;
            }
            else
            {
                ArrayList result = (ArrayList)responce.Value;
                return result;
            }

        }

    }
}
