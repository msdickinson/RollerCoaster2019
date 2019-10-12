using System;
using System.Collections.Generic;
using System.Text;

namespace RollerCoaster2019.Contracts
{
    public class LoginDescriptor
    {
        public bool Succesful { get; set; }
        public bool LoginFailure { get; set; }
        public bool ServerFailure { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDateTime { get; set; }
    }
}
