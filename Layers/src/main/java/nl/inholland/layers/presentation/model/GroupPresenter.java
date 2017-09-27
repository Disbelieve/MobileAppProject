/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.presentation.model;

import java.util.ArrayList;
import java.util.List;
import nl.inholland.layers.model.Group;
import nl.inholland.layers.model.User;

/**
 *
 * @author youp
 */
public class GroupPresenter extends BasePresenter
{

    public List<GroupView> present(List<Group> groups)
    {
        List<GroupView> view = new ArrayList<GroupView>();
        
        for(Group group : groups){
            GroupView viewGroup = new GroupView();
            viewGroup.id = group.getId();
            
            List<UserView> membersView = new ArrayList<UserView>();
            for(User user : group.getMembers()){
                UserView viewUser = new UserView();
                
                viewUser.id = user.getId();
                viewUser.married = user.isMarried();
                viewUser.name = user.getName();
                
                membersView.add(viewUser);
            }
            viewGroup.members = membersView;
            viewGroup.name = group.getName();
            
            view.add(viewGroup);
        }
        
        return view;
    }


    public GroupView present(Group group)
    {
        GroupView view = new GroupView();
        view.id = group.getId();
        
        List<UserView> members = new ArrayList<UserView>();
        
        for(User user : group.getMembers()){
            UserView viewUser = new UserView();
            viewUser.id = user.getId();
            viewUser.married = user.isMarried();
            viewUser.name = user.getName();
            
            members.add(viewUser);
        }
        
        view.members = members;
        view.name = group.getName();
        
        return view;
    }
    
}
