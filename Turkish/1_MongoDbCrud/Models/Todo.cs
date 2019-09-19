using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogTodoApp.Models
{

    public class Todo
    {

        public ObjectId Id { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Date")]
        public string Date { get; set; }

        [BsonElement("Completed")]
        public bool Completed { get; set; }

    }

}
