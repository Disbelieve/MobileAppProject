/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.presentation.model;

import java.util.ArrayList;
import java.util.List;
import nl.inholland.layers.model.User;

/**
 *
 * @author youp
 */
public class UserPresenter extends BasePresenter
{
    public List<UserView> present(List<User> users)
    {
        List<UserView> view = new ArrayList<UserView>();

        for(User user : users){
            UserView viewUser = new UserView();

            viewUser.setId(user.getId());
            viewUser.setName(user.getName());
            viewUser.setMarried(user.isMarried());
            view.add(viewUser);
        }
        return view;
        
    }

    public UserView present(User user)
    {
        UserView view = new UserView();
        view.setId(user.getId());
        view.setName(user.getName());
        view.setMarried(user.isMarried());
        
        return view;
    }
    
}
