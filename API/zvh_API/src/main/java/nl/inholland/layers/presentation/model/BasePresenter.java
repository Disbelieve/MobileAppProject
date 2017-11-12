/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.presentation.model;

import javax.inject.Singleton;
import nl.inholland.layers.model.EntityModel;

@Singleton
public abstract class BasePresenter<T extends EntityModel> 
{
    public T present(T obj)
    {
        return obj;
    }

}
