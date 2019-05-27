using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mvc_MongoDB.Models
{
    public class Pais
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        [Required]
        [Display(Name="Nome")]
        public String PaisCodigo { get; set; }

        [Required]
        [Display(Name = "País")]
        public String PaisNome { get; set; }

        [Required]
        [Display(Name = "População")]
        public double PaisPopulacao { get; set; }
    }
}