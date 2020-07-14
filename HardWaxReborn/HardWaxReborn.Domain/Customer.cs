using System;
using System.Collections.Generic;
using System.IO;

namespace HardWaxReborn.Domain
{
    public class Customer
    {
        private readonly string _firstName;

        private readonly string _lastName;

        private readonly string _userName;
        
        public int Id { get; set; }
        public string FirstName 
        { get => _firstName;
            set
            { if (value is string)
                {
                    _ = _firstName;
                } else
                {
                    throw new InvalidDataException("Invalid First Name");
                }
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value is string)
                {
                    _ = _lastName;
                }
                else
                {
                    throw new InvalidDataException("Invalid Last Name");
                }
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                if (value is string)
                {
                    _ = _userName;
                }
                else
                {
                    throw new InvalidDataException("Invalid Last Name");
                }
            }
        }


        public string Name { get => _firstName + " " + _firstName;  }

        public List<Order> OrderHistory { get; set; }

        public Customer (int id, string firstName, string lastName, string userName)
        {
            _firstName = firstName;
            _lastName = lastName;
            _userName = userName;
            Id = id;
        }
    }
        

}
