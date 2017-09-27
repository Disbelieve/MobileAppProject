/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.service;

import java.util.ArrayList;
import java.util.List;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import nl.inholland.layers.model.User;
import nl.inholland.layers.persistence.MockDB;

/**
 *
 * @author youp
 */
public class UserService extends BaseService
{
    public UserService(){
        
    }
    
    @GET
    @Path("{userId}")
    public User get(@PathParam("userId")String userId)
    {
        return MockDB.users.get(userId);
    }

    @GET
    public List<User> getAll()
    {
        List<User> users = new ArrayList<User>(MockDB.users.values());
        return users;
    }
    
}
