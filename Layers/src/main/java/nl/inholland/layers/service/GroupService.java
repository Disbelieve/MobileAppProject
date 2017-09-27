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
import nl.inholland.layers.model.Group;
import nl.inholland.layers.model.User;
import nl.inholland.layers.persistence.MockDB;

/**
 *
 * @author youp
 */
public class GroupService extends BaseService
{
    public GroupService(){
        
    }
    
    @GET
    @Path("{userId}")
    public Group get(@PathParam("groupId")String groupId)
    {
        return MockDB.groups.get(groupId);
    }
    
    @GET
    public List<Group> getAll()
    {
        List<Group> groups = new ArrayList<Group>(MockDB.groups.values());
        return groups;
    }
    
}
