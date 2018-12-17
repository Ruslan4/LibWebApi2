using System;
using System.Collections.Generic;

namespace BestLibrary.Models
{
    /// <summary>
    /// Models returned by actions AccountController.
    /// </summary>
    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }
    /// <summary>
    /// Models returned by actions AccountController.
    /// </summary>
    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }
    /// <summary>
    /// Models returned by actions AccountController.
    /// </summary>
    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }
    /// <summary>
    /// Models returned by actions AccountController.
    /// </summary>
    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
