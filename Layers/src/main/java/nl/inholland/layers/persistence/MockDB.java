package nl.inholland.layers.persistence;

import java.util.HashMap;
import java.util.Map;

import javax.inject.Singleton;
import nl.inholland.layers.model.Group;
import nl.inholland.layers.model.User;

@Singleton
public class MockDB
{
    public final static Map<String,User> users = new HashMap<>();

    public final static Map<String,Group> groups = new HashMap<>();
    
    public static void init()
    {
        addNewUser( "10", "Nelleke", "test", true );
        addNewUser( "12", "Piet", "test", false );
        addNewUser( "14", "Luke", "test", true );
        addNewUser( "16", "Mohammed", "test", true );
        addNewUser( "18", "Ludwig", "test", false );
        addNewUser( "20", "Xiu", "test", false );
        addNewUser( "22", "Iris", "test", true );
        addNewUser( "24", "John", "test", false );
        addNewUser( "26", "Abdel", "test", true );
        addNewUser( "28", "Fatima", "test", false );

        addGroup( "44", "De dames", new String[] {"10", "20", "22", "28"} );
        addGroup( "55", "De heren", new String[] {"12", "14", "16", "18", "24", "26"} );
        addGroup( "66", "Gehuwden", new String[] {"10", "14", "16", "22", "26"} );
    }

    private static void addNewUser( String id, String name, String password, boolean married )
    {
        User user = new User() {};
        
        user.setId( id );
        user.setName( name );
        user.setPassword( password );
        user.setMarried( married );
        
        users.put( id, user );
    }

    private static void addGroup( String id, String name, String[] memberIds )
    {
        Group group = new Group();
        
        group.setId( id );
        group.setName( name );
        for ( String memberId : memberIds )
            group.addMember( users.get( memberId ) );
        
        groups.put( id, group );
    }

    public static User getUserByName(String name)
    {
        for (User user : users.values())
        {
            if (user.getName().equals(name))
                return user;
        }
        return null;
    }
}