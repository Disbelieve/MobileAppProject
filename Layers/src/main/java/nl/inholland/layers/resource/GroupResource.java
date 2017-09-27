/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.resource;

import java.util.List;
import javax.inject.Inject;
import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import nl.inholland.layers.presentation.model.GroupPresenter;
import nl.inholland.layers.presentation.model.GroupView;
import nl.inholland.layers.service.GroupService;
import nl.inholland.layers.model.Group;


/**
 *
 * @author youp
 */
@Path("/groups")
@Consumes (MediaType.APPLICATION_JSON)
@Produces (MediaType.APPLICATION_JSON)
public class GroupResource extends BaseResource
{
    private final GroupService groupService;
    private final GroupPresenter groupPresenter;
    
    @Inject
    public GroupResource( GroupService groupService,
            GroupPresenter groupPresenter){
        this.groupService = groupService;
        this.groupPresenter = groupPresenter;
    }
    
    @GET
    public List<GroupView> getAll(){
        List<Group> groups = groupService.getAll();
        
        return groupPresenter.present(groups);
    }
    
    @GET
    @Path("/{groupId}")
    public GroupView get( @PathParam("groupId") String groupId){
        Group group = groupService.get(groupId);
        
        return groupPresenter.present(group);
    }
    
    @POST
    public void create(Group group){
        
    }
    
//    @GET
//    @Path("/{groupId}/members")
//    public GroupView get (@PathParam("groupId") String groupId){
//        Group group = groupPresenter.get(groupId);
//        
//        return groupPresenter.present(group);
//    }
}

