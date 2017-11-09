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
    private String emailAdress;   
    private String firstname;
    private String lastname;
    
    @Reference(idOnly = true)
    private Consultant consultantId;
    
    private String dateOfBirth;
    private int gender;
    private int length;
    private int weight;
    private String passwordHash;
    private String authToken;
    private String resetPasswordToken;
    private String passwordTokenExpiry;
    
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
        return consultantId;
    }
    public void setConsultant(Consultant consultantId)
    {
        this.consultantId = consultantId;
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
        return emailAdress;
    }

    public void setEmail(String email)
    {
        this.emailAdress = email;
    }
    
    public String getFirstName()
    {
        return firstname;
    }

    public void setFirstName(String firstname)
    {
        this.firstname = firstname;
    }
    public String getPasswordHash()
    {
        return passwordHash;
    }

    public void setPasswordHash(String passwordHash)
    {
        this.passwordHash = passwordHash;
    }
        public String getResetPasswordToken()
    {
        return resetPasswordToken;
    }

    public void setresetPasswordTokenh(String resetPasswordToken)
    {
        this.resetPasswordToken = resetPasswordToken;
    }
    
    public String getPasswordTokenExpiry()
    {
        return passwordTokenExpiry;
    }

    public void setPasswordTokenExpiry(String passwordTokenExpiry)
    {
        this.passwordTokenExpiry = passwordTokenExpiry;
    }
    public String getAuthToken()
    {
        return authToken;
    }

    public void setAuthToken(String authToken)
    {
        this.authToken = authToken;
    }
    public String getLastName()
    {
        return lastname;
    }
    
    public void setLastName(String lastname)
    {
        this.lastname = lastname;
    }
    
    public int getGender()
    {
        return gender;
    }
    
    public void setGender(int gender)
    {
        this.gender = gender;
    }


    
    
}
