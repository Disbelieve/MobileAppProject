/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.persistence;

import java.util.List;
import javax.inject.Inject;
import nl.inholland.layers.model.User;
import org.bson.types.ObjectId;
import org.mongodb.morphia.Datastore;
import org.mongodb.morphia.query.Query;

public class UserDAO extends BaseDAO<User>
{
    private final Datastore datastore;
    private ObjectId objectId;
    @Inject
    public UserDAO(Datastore ds)
    {
        super(User.class, ds);
        this.datastore = ds;
    }
    
    @Override
    public List<User> getAll() {
       List<User> users = datastore.createQuery(User.class).asList();       
       return users;
    }

    
    public User getById(ObjectId userId){
        
        Query<User> query = createQuery().field("_id").equal(userId);
        return findOne(query);
    }

}