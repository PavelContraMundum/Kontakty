using System;


namespace ContactList
{
    internal class Contact
    {
        private string firstName;
        private string lastName;
        private string phone;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Phone
        {
            get { return phone; }
            set {
                if (value.Length == 10)
                {
                    phone = value;
                }
                else
                {
                    phone = "0000000000";
                }
            }
        }

        public Contact() 
            {
            FirstName = "John";
            LastName = "Doe";
            Phone = "0000000000";
            }

        public Contact(string firstName, string lastName, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }
      

    } //end of class
} // end of namespace
