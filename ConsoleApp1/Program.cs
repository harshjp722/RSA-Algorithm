using System;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    class Program
    {
        public const string RSAPrivateKey = @"<?xml version=""1.0"" encoding=""utf-8""?><RSAParameters xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><Exponent>AQAB</Exponent><Modulus>2C1hiaRXrqWa0qoCPhkbDyJxrDlENAZ0nNv8v1y7hfBpGRfWObmZ+zVhPxw//7M1WApCgCXtVhvff8gCs0ByGeRd1FVODxaTFwvfMQ6lNPsUhOsdpXYO6++ThmbJD3RxdY2LqiBfIvMX8qgW/wV12jNzkPWctErFUujXRdJJrLHIpqi40cQPHV3kzudWth+5L7WtTUOOfesII2o3IJeOCFjEhLQo6RK5BUyRUJaCVhf+m1GWBO9C2ao8YVWZVsB7OWO3snF8bCEplfTbSrfl6gcsQiTR9A2tCq82QeMNGJfjU1+VuQBhOUXMg+v4zhSAEeNrzp/zphbtseP3S5v1dQ==</Modulus><P>2QuxJh5evX5dP6nfRuP9FpwqChJlaKkReosOWCb8v/WPETfE/NLWoYXd9K+oU/6h+o+9dnZrB48DyScFyjA7j1YoBNPjkX7BM+gI0yf30PbkBY6Fj5Al514obwUIniKLxR9Y8rFII+A72MIxdTofOyMQW1HVMiYMG5aOjH72Ew8=</P><Q>/vnKKZ/LYNsaJ9pcSVcjCvYQNqLvVxTuDeXbmBL8YWGvxJ8HPFOsZiIvCFu2rShEigOlcZIuFi4mNqADyP0BB6JA1orb134re6t4r8/YxKQe/FvM8VaH6HzsosF8WfFJEe3dPVw+lRnSec4cz5vS8RtgADKulJdiGbZXsf79Xzs=</Q><DP>XK1xZyVwrtlWV+jhPhP77bug98wDIT2QCRN3fIypQA5KmL+Hja05mJ7gt6qJ5dPEtojKDdtiuEeJBktzXXJa/El9rRINCgNl3BQoMIHQf5nso7LHtRWIGdNK0J0FoQB/ThykjnzEoQ0OgO/qznOTAl1mjpfSwScd5GnVVIih6mE=</DP><DQ>Lt2e6RO0ADOFlTmvqNNZX5Rm2oQMVgdE0k0jlco3lXatJgjM/aurjoJN/s1MwHscTfnpmPxzeCQ3Zeb3iyPl4o9SN50CV5ObTnnwDvC3OT2pbF07SEjNZlA/9pJ11tpgwejkt3iTEDjU1QqrhQVxOlv7w02NhUZmA6/eYpsp2y0=</DQ><InverseQ>0M/kRhNnW4rAnmb+mxFBeHO7MvERCgHPD7gxPpOF4JQX4ezoNud+6c+iAImP6fAM7aPyJ+2lI4PVbUiKAKgZttiK14m1eW8FDjH3/OsJGF+SZEgPqe5OQ7W1+ZTIoA3zvFHKbXPoMoOierqRNJYDP9NWFfqzFGL32IweUQtPn4A=</InverseQ><D>WUWkWer8KqtI3GZItsw3WHCo8K5VdAaWcZCHN59b8VvuiuZFGWGELTFGD4HjC/09sjXKcJE5Ca5JBcPbGZsrg3XDKcRwj9qKs6G7cc7SeqaVOq69d27hip1NFturfC5iDGF/o6nqn8wzv4matYXTvWAyAVLse6fFBRASlkrZEe82N9lA409XFg9A/m0hcfnK6sXlenir+KWP/m7q2KHj0N8cqcR2RqqAXDm9STg6qPqNomj2gJYyjSqH3FA42zwULqFqC0YmsG3DVO+9Mb9Ect0Nf2bjAdrsxJOrLScVFvpVP0QpMD71M+X8/pXJlFbYtyF1QKWSBiJmw43jm0pToQ==</D></RSAParameters>";
        public const string RSAPublicKey = @"<?xml version=""1.0"" encoding=""utf-8"" ?><RSAParameters xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><Exponent>AQAB</Exponent><Modulus>2C1hiaRXrqWa0qoCPhkbDyJxrDlENAZ0nNv8v1y7hfBpGRfWObmZ+zVhPxw//7M1WApCgCXtVhvff8gCs0ByGeRd1FVODxaTFwvfMQ6lNPsUhOsdpXYO6++ThmbJD3RxdY2LqiBfIvMX8qgW/wV12jNzkPWctErFUujXRdJJrLHIpqi40cQPHV3kzudWth+5L7WtTUOOfesII2o3IJeOCFjEhLQo6RK5BUyRUJaCVhf+m1GWBO9C2ao8YVWZVsB7OWO3snF8bCEplfTbSrfl6gcsQiTR9A2tCq82QeMNGJfjU1+VuQBhOUXMg+v4zhSAEeNrzp/zphbtseP3S5v1dQ==</Modulus></RSAParameters>";
        static void Main(string[] args)
        {
            //lets take a new CSP with a new 2048 bit rsa key pair
            var csp = new RSACryptoServiceProvider(2048);

            //how to get the private key
            //var privKey = ConvertRSAKeyToString(csp.ExportParameters(true));
            //and the public key  - private and public keys have 1-1 correspondence
            //var pubKey = ConvertRSAKeyToString(csp.ExportParameters(false));
            //Console.WriteLine("Private Key: \n" + privKey);
            //Console.WriteLine("\nPublic Key: \n" + pubKey);
                        
            //we have a public key ... let's get a new csp and load that key
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(ConvertStringToRSAKey(RSAPublicKey));

            //Encryption Function
            //we need some data to encrypt
            var Message = "My name is harsh";
            //for encryption, always handle bytes...
            var bytesPlainTextData = System.Text.Encoding.Unicode.GetBytes(Message);
            //apply pkcs#1.5 padding and encrypt our data 
            var bytesCypherText = csp.Encrypt(bytesPlainTextData, false);
            //we might want a string representation of our cypher text... base64 will do
            var cypherText = Convert.ToBase64String(bytesCypherText);

            //Decryption Function
            //first, get our bytes back from the base64 string ...
            bytesCypherText = Convert.FromBase64String(cypherText);
            //we want to decrypt, therefore we need a csp and load our private key
            csp = new RSACryptoServiceProvider();
            csp.ImportParameters(ConvertStringToRSAKey(RSAPrivateKey));
            //decrypt and strip pkcs#1.5 padding
            bytesPlainTextData = csp.Decrypt(bytesCypherText, false);
            //get our original plainText back...
            var plainTextData = System.Text.Encoding.Unicode.GetString(bytesPlainTextData);

            Console.WriteLine("\nCypher Text: \n" + cypherText);
            Console.WriteLine("\nOriginal Message: \n" + plainTextData);
            Console.ReadKey();
        }

        private static string ConvertRSAKeyToString(RSAParameters key)
        {
            //converting the RSA key into a string representation
            //we need some buffer
            var sw = new System.IO.StringWriter();
            //we need a serializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //serialize the key into the stream
            xs.Serialize(sw, key);
            //get the string from the stream
            string KeyString = sw.ToString();
            return KeyString;
        }

        private static RSAParameters ConvertStringToRSAKey(string RSAStringKey)
        {
            //converting it back
            //get a stream from the string
            var sr = new System.IO.StringReader(RSAStringKey);
            //we need a deserializer
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
            //get the object back from the stream
            var RSAKey = (RSAParameters)xs.Deserialize(sr);
            return RSAKey;
        }
    }
}
