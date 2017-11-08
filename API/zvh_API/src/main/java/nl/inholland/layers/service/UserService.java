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
    
    @Inject
    public UserService(UserDAO userDAO){
        this.userDAO = userDAO;
    }
    
    public User get(ObjectId userId)
    {
        User user = userDAO.getById(userId);
        return user;
    }

    public void create(User user){
        userDAO.create(user);
    }
    
    public List<User> getAll()
    {
        List<User> users = userDAO.getAll();
        
        if (users.isEmpty())
            resultService.requireResult(users, "geen gebruikers");

        return users;
    }

    public void update(String userId, User user){
        ObjectId objectId;
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