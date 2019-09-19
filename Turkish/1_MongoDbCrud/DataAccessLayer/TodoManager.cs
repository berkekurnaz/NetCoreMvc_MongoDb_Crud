using BlogTodoApp.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTodoApp.DataAccessLayer
{
    public class TodoManager
    {

        private readonly IMongoCollection<Todo> mongoCollection;

        public TodoManager(string mongoDbConnectionString, string dbName, string collectionName)
        {
            var client = new MongoClient(mongoDbConnectionString);
            var database = client.GetDatabase(dbName);
            mongoCollection = database.GetCollection<Todo>(collectionName);
        }

        /* Butun Todo'lari Listeleme */
        public List<Todo> GetList()
        {
            return mongoCollection.Find(book => true).ToList();
        }

        /* Bir Todo Getirme */
        public Todo GetById(string id)
        {
            var docId = new ObjectId(id);
            return mongoCollection.Find<Todo>(m => m.Id == docId).FirstOrDefault();
        }

        /* Yeni Bir Todo Ekleme */
        public Todo Create(Todo model)
        {
            mongoCollection.InsertOne(model);
            return model;
        }

        /* Bir Todo Guncelleme */
        public void Update(string id, Todo model)
        {
            var docId = new ObjectId(id);
            mongoCollection.ReplaceOne(m => m.Id == docId, model);
        }

        /* Bir Todo Silme */
        public void Delete(string id)
        {
            var docId = new ObjectId(id);
            mongoCollection.DeleteOne(m => m.Id == docId);
        }

    }
}
