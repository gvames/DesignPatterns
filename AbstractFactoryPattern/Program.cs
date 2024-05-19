using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Utilizare pentru conexiuni la baze de date SQL
            Client sqlClient = new Client(new SqlConnectionFactory());
            sqlClient.Run();

            // Utilizare pentru conexiuni la baze de date Oracle
            Client oracleClient = new Client(new OracleConnectionFactory());
            oracleClient.Run();

            Console.ReadLine();
        }
    }

    // Interfața abstractă pentru fabrica de conexiuni la baze de date
    public interface IDatabaseFactory
    {
        IDbConnection CreateConnection();
        IDbCommand CreateCommand();
    }

    // Clasa abstractă pentru conexiunile la baze de date
    public interface IDbConnection
    {
        void Open();
        void Close();
    }

    // Clasa abstractă pentru comenzile bazate pe conexiune
    public interface IDbCommand
    {
        void Execute();
    }

    // Implementarea fabricii concrete pentru conexiunile la baze de date SQL
    public class SqlConnectionFactory : IDatabaseFactory
    {
        public IDbConnection CreateConnection()
        {
            return new SqlConnection();
        }

        public IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }
    }

    // Implementarea fabricii concrete pentru conexiunile la baze de date Oracle
    public class OracleConnectionFactory : IDatabaseFactory
    {
        public IDbConnection CreateConnection()
        {
            return new OracleConnection();
        }

        public IDbCommand CreateCommand()
        {
            return new OracleCommand();
        }
    }

    // Implementarea clasei de conexiune SQL
    public class SqlConnection : IDbConnection
    {
        public void Open()
        {
            Console.WriteLine("SQL Connection opened.");
        }

        public void Close()
        {
            Console.WriteLine("SQL Connection closed.");
        }
    }

    // Implementarea clasei de conexiune Oracle
    public class OracleConnection : IDbConnection
    {
        public void Open()
        {
            Console.WriteLine("Oracle Connection opened.");
        }

        public void Close()
        {
            Console.WriteLine("Oracle Connection closed.");
        }
    }

    // Implementarea clasei de comandă SQL
    public class SqlCommand : IDbCommand
    {
        public void Execute()
        {
            Console.WriteLine("SQL Command executed.");
        }
    }

    // Implementarea clasei de comandă Oracle
    public class OracleCommand : IDbCommand
    {
        public void Execute()
        {
            Console.WriteLine("Oracle Command executed.");
        }
    }

    // Clientul care utilizează fabrica abstractă
    public class Client
    {
        private IDatabaseFactory _factory;

        public Client(IDatabaseFactory factory)
        {
            _factory = factory;
        }

        public void Run()
        {
            IDbConnection connection = _factory.CreateConnection();
            IDbCommand command = _factory.CreateCommand();

            connection.Open();
            command.Execute();
            connection.Close();
        }
    }
}
