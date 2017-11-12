/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.service;

import java.util.List;
import javax.inject.Inject;
import javax.ws.rs.NotFoundException;
import nl.inholland.layers.model.User;
import nl.inholland.layers.persistence.UserDAO;
import org.bson.types.ObjectId;
import org.mongodb.morphia.query.Query;
import org.mongodb.morphia.query.UpdateOperations;

public class UserService extends BaseService
{

    private final UserDAO userDAO;
    private ObjectId objectId;

    @Inject
    public UserService(UserDAO userDAO){
        this.userDAO = userDAO;
    }
    
    public User get(String userId)
    { 
        
        User user = null;
        
        try{
        if(ObjectId.isValid(userId)){
             objectId = new ObjectId(userId);
             user = userDAO.getById(objectId);         
        }
        
        }catch(Exception e)
        {
            e.getMessage();
        }
          return user;
    }

    public void create(User user){
        
       try{
        
           checkEntryValidity(user);
        checkDuplicate(user);
        userDAO.create(user);
       }
       catch(Exception e)
       {
           e.getMessage();
       }
    }
    
    public List<User> getAll()
    {
        List<User> users = null;
        try{
          
            users = userDAO.getAll();  
            if (users.isEmpty()) {
                
                requireResult(users, "geen resultaten gevonden");
            }    
        }
        catch(NotFoundException e)
        {
            e.getMessage();
        }
        
        return users;
    }

    public void update(String userId, User user){
        
        try{
            
        if(ObjectId.isValid(userId)){
            objectId = new ObjectId(userId);
            Query query = userDAO.createQuery().field("_id").equal(objectId);
            UpdateOperations<User> ops = userDAO.createUpdateOperations();
            userDAO.update(query, ops);
        }
        else
            noValidObjectId("Gebruiker is niet geldig");       
        
        }catch(Exception e)
        {
            e.getMessage();
        }
  }
    
        private void checkEntryValidity(User u)
    {
        if ("".equals(u.getFirstName()) || u.getFirstName() == null)
            emptyField("name cannot be an empty");
        
        if ("".equals(u.getLastName()) || u.getLastName() == null)
            emptyField("gender cannot be an empty");
    }
    
    public void checkDuplicate(User user)
    {
        List<User> users = userDAO.getAll();
        for (User u : users)
        {
            if (u.getFirstName().equals(user.getFirstName()))
            {
                duplicateDocument("A user with the name " + user.getFirstName() + " already exists.");
            }
        }
    }
}