/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.model;

import org.mongodb.morphia.annotations.Entity;

@Entity(value = "consultants")
public class Consultant extends EntityModel
{
    private String firstname;
    private String lastname;
    private String emailAdress;
        

   public String getFirstname()
    {
        return firstname;
    }

    public void setfirstname(String firstname)
    {
        this.firstname = firstname;
    }

    public String getLastname()
    {
        return lastname;
    }

    public void setLastname(String lastname)
    {
        this.lastname = lastname;
    }

    public String getEmailAdress()
    {
        return emailAdress;
    }

    public void setGender(String emailAdress)
    {
        this.emailAdress = emailAdress;
    }  
}
