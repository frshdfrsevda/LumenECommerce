using CetinFarshidfar.JewelryECommerce.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites
{
    public class Company : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Website { get; set; }
        public DateTime FoundedDate { get; set; }
        public int NumberOfEmployees { get; set; }
        public string Industry { get; set; }
        public string Description { get; set; }
        public Guid CoFounderId { get; set; }
        [ForeignKey(nameof(CoFounderId))]
        public AppUser CoFounder { get; set; }

        // Constructor
        public Company() { }
        public Company(string name, string address, string city, string state, string postalCode, 
            string country, string phone, string email, string? website, DateTime foundedDate, 
            int numberOfEmployees, string industry, string description, Guid coFounderId)
        {
            Name = name;
            Address = address;
            City = city;
            State = state;
            PostalCode = postalCode;
            Country = country;
            Phone = phone;
            Email = email;
            Website = website;
            FoundedDate = foundedDate;
            NumberOfEmployees = numberOfEmployees;
            Industry = industry;
            Description = description;
            CoFounderId = coFounderId;
        }
    }
}
