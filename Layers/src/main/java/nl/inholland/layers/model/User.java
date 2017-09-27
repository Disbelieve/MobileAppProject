package nl.inholland.layers.model;

import java.security.Principal;

public class User extends EntityModel implements Principal
{
    private String name;
    
    private String password;
    
    private boolean married;

    public String getName()
    {
        return name;
    }

    public void setName( String name )
    {
        this.name = name;
    }

    public String getPassword()
    {
        return password;
    }

    public void setPassword( String password )
    {
        this.password = password;
    }

    public boolean isMarried()
    {
        return married;
    }

    public void setMarried( boolean married )
    {
        this.married = married;
    }

    
}