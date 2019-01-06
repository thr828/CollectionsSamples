using System.Collections.Generic;

namespace Wrox.ProCSharp.Collections
{
    public class DocumentManager
    {
        private readonly Queue<Document> documentQueue = new Queue<Document>();

        public void AddDocument(Document doc)
        {
            lock (this)
            {
                documentQueue.Enqueue(doc); //添加队列
            }
        }

        public Document GetDocument()
        {
            Document doc = null;
            lock (this)
            {
                doc = documentQueue.Dequeue();//取出队列，并删除此队列
            }
            return doc;
        }

        public bool IsDocumentAvailable
        {
            get
            {
                return documentQueue.Count > 0;
            }
        }
    }

}
