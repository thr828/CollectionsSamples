using System;
using System.Threading;

namespace Wrox.ProCSharp.Collections
{
    public class ProcessDocuments
    {
        private DocumentManager documentManager;

        protected ProcessDocuments(DocumentManager dm)
        {
            documentManager = dm;
        }


        public static void Start(DocumentManager dm)
        {
            new Thread(new ProcessDocuments(dm).Run).Start();
        }

   
        protected void Run()
        {
            while (true)
            {
                if (documentManager.IsDocumentAvailable)
                {
                    Document doc = documentManager.GetDocument();
                    Console.WriteLine("Processing document {0}，Current ThreadId {1}", doc.Title,  Thread.CurrentThread.ManagedThreadId);
                }
                Thread.Sleep(new Random().Next(20));
            }
        }
    }

}
