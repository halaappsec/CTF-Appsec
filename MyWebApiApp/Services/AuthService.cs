using System.Collections.Generic;
using System;

namespace MyWebApiApp.Services
{
    public class AuthService
    {
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>();

        public AuthService()
        {
            // Fetch credentials from environment variables

            string adminUsername = Environment.GetEnvironmentVariable("ADMIN_USERNAME");
            string adminPassword = Environment.GetEnvironmentVariable("ADMIN_PASSWORD");

            // Initialize with one user for testing, fetched from environment variables
            if (!string.IsNullOrWhiteSpace(adminUsername) && !string.IsNullOrWhiteSpace(adminPassword))
            {
                _users.Add(adminUsername, adminPassword);
            }
        }

        public bool ValidateLogin(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            return _users.TryGetValue(username, out var storedPassword) && storedPassword == password;
        }
    }
}
  
