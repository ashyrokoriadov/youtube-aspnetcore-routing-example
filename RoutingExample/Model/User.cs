﻿namespace RoutingExample.Model
{
    public class User
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{nameof(Login)}: {Login}; " +
                $"{nameof(FirstName)}: {FirstName}; " +
                $"{nameof(LastName)}: {LastName};";
        }
    }
}
