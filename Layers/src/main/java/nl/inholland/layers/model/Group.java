package nl.inholland.layers.model;

import java.util.ArrayList;
import java.util.List;

public class Group extends EntityModel
{
    private String name;
    private List<User> members = new ArrayList<>();
    
    public String getName()
    {
        return name;
    }
    
    public void setName( String name )
    {
        this.name = name;
    }
    
    public List < User > getMembers()
    {
        return members;
    }
    
    public void setMembers( List < User > members )
    {
        this.members = members;
    }
    
    public void addMember( User user )
    {
        members.add( user );
    }

    public boolean isMember( User user )
    {
        return members.contains( user );
    }
}