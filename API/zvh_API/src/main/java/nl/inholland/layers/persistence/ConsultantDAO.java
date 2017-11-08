/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package nl.inholland.layers.persistence;

import java.util.List;
import javax.inject.Inject;
import nl.inholland.layers.model.Consultant;
import org.mongodb.morphia.Datastore;

public class ConsultantDAO extends BaseDAO<Consultant> {

    private final Datastore datastore;

    @Inject
    public ConsultantDAO(Datastore ds) {
        super(Consultant.class, ds);
        this.datastore = ds;
    }

    @Override
    public List<Consultant> getAll() {
       List<Consultant> consultants = datastore.createQuery(Consultant.class).asList();
       
       return consultants;
    }

}
