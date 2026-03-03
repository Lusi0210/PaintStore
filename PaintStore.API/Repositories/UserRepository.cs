using System;
using Microsoft.EntityFrameworkCore;
using PaintStore.API.DataAccess;
using PaintStore.Models;

namespace PaintStore.API.Repositories;

public class UserRepository
{
    private PaintStoreDbContext _dbContext;

    public UserRepository()
    {

    }
    public User AddUserToDb(User user)
    {
        //Add only mark user to be added
        _dbContext.Users.Add(user);

        //save to db
        int changes = _dbContext.SaveChanges();
        if (changes > 0)
        {
            return user;
        }

        else
        {
            throw new DbUpdateException("Add User failed");
        }

    }
}
