/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.service;

import java.util.List;
import javax.inject.Inject;
import nl.inholland.layers.model.User;
import nl.inholland.layers.persistence.UserDAO;
import org.bson.types.ObjectId;
import org.mongodb.morphia.query.Query;
import org.mongodb.morphia.query.UpdateOperations;

public class UserService extends BaseService
{

    private final UserDAO userDAO;
    private final ResultService resultService = new ResultService();
    private ObjectId objectId;

    @Inject
    public UserService(UserDAO userDAO){
        this.userDAO = userDAO;
    }
    
    public User get(String userId)
    {       
        User user = null;
        if(ObjectId.isValid(userId)){
             objectId = new ObjectId(userId);
             user = userDAO.getById(objectId);
          
        }
          return user;
    }

    public void create(User user){
        userDAO.create(user);
    }
    
    public List<User> getAll()
    {
        List<User> users = userDAO.getAll();
        
        return users;
    }

    public void update(String userId, User user){
        if(ObjectId.isValid(userId)){
            objectId = new ObjectId(userId);
            Query query = userDAO.createQuery().field("_id").equal(objectId);
            UpdateOperations<User> ops = userDAO.createUpdateOperations();
            userDAO.update(query, ops);
        }
        else
            resultService.noValidObjectId("Gebruiker is niet geldig");
    }
    
}