using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Agenda 
 * - Unit Testing Review
 * - Mocking objects
 * - Legacy Codebases not built for Unit Testing
 */

namespace UnitTestingDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public interface INotify
    {
        void Send(string message);
    }

    public class Calculator
    {
        private readonly INotify notifier;

        public Calculator(INotify notifier)
        {
            this.notifier = notifier;
        }

        public int Add(int a, int b)
        {
            int result = a + b;
            notifier.Send($"Add was called with a result of : {result}");
            return result;
        }
    }


    public class DoDbThings
    {
        private readonly DbConnection connection = null;  // new.....
        private readonly Program p = null; // new ....
        private readonly DoDbThingsTestable t;

        public DoDbThings()
        {
            t = new DoDbThingsTestable(connection);
        }

        public void M1()
        {
            connection.Open();
            // things
            connection.Close();
        }

        public void M2()
        {
            t.M2();
        }

        internal class DoDbThingsTestable
        {
            private readonly IDbConnection connection;

            public DoDbThingsTestable(IDbConnection connection)
            {
                this.connection = connection;
            }

            public void M2()
            {
                connection.Open();
                // and other things
                connection.Close();
            }
        }

    }
}
