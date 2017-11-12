/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.presentation.model;

import java.util.List;
import nl.inholland.layers.model.User;

public class UserPresenter extends BasePresenter
{


    public User present(User user)
    {
        return user;
    }

    public List<User> present(List<User> users) {
       return users;
    }

}
