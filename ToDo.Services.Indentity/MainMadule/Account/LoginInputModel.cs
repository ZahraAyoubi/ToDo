// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;
using ToDo.Services.Indentity.MainMadule.Account;

namespace IdentityServerHost.Quickstart.UI
{
    public class LoginInputModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
        public Role RoleName { get; set; }
    }
}