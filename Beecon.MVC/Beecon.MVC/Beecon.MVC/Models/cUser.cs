﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Beecon.Models
{
    public class cUser
    {
        #region Properties

        Guid id;
        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        string gender;
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        string zip;
        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        DateTime? dob;
        public DateTime? Dob
        {
            get { return dob; }
            set { dob = value; }
        }

        string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        int? beeconsFound;
        public int? BeeconsFound
        {
            get { return beeconsFound; }
            set { beeconsFound = value; }
        }

        int? beeconsCreated;
        public int? BeeconsCreated
        {
            get { return beeconsCreated; }
            set { beeconsCreated = value; }
        }
        #endregion


        public cUser()
        {

        }
        public cUser(Guid _id, string _lastName, string _firstName, string _email, string _gender, string _address, string _city, string _state, string _zip, DateTime? _dob, string _password, int? _beeconsCreated, int? _beeconsFound)
        {
            id = _id;
            lastName = _lastName;
            firstName = _firstName;
            email = _email;
            gender = _gender;
            address = _address;
            city = _city;
            state = _state;
            zip = _zip;
            dob = _dob;
            password = _password;
            beeconsCreated = _beeconsCreated;
            beeconsFound = _beeconsFound;



        }


    }
}
