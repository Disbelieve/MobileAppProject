/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.model;

import org.mongodb.morphia.annotations.Entity;
import org.mongodb.morphia.annotations.Reference;

@Entity(value = "users")
public class User extends EntityModel 
{
    private String email;   
    private String firstname;
    private String lastname;
    
    @Reference
    private Consultant consultant;
    private String dateOfBirth;
    private String gender;
    private int length;
    private int weight;
 
    public int getweight()
    {
        return weight;
    }
    public void setweight(int weight)
    {
        this.weight = weight;
    }
    
    public int getLength()
    {
        return length;
    }
    public void setLength(int length)
    {
        this.length = length;
    }
    
    public Consultant getConsultant()
    {
        return consultant;
    }
    public void setConsultant(Consultant consultant)
    {
        this.consultant = consultant;
    }
    
    public String getdateOfBirth()
    {
        return dateOfBirth;
    }
    public void setdateOfBirth(String dateOfBirth)
    {
        this.dateOfBirth = dateOfBirth;
    }
    
    public String getEmail()
    {
        return email;
    }

    public void setEmail(String email)
    {
        this.email = email;
    }
    
    public String getFirstName()
    {
        return firstname;
    }

    public void setFirstName(String firstname)
    {
        this.firstname = firstname;
    }
    public String getLastName()
    {
        return lastname;
    }
    
    public void setLastName(String lastname)
    {
        this.lastname = lastname;
    }
    
    public String getGender()
    {
        return gender;
    }
    
    public void setGender(String gender)
    {
        this.gender = gender;
    }

    public Object getName() {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }


    
    
}
