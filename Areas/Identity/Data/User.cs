using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassageStudio.App.Models;
using Microsoft.AspNetCore.Identity;

namespace MassageStudio.Areas.Identity.Data;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    public User() : base()
    {
        Id = Guid.NewGuid().ToString();
        SecurityStamp = Guid.NewGuid().ToString();
    }
    public virtual List<Massage> massages { get; set; } = new List<Massage>();

}

