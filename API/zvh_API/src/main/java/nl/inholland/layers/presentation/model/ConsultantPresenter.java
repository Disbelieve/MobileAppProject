package nl.inholland.layers.presentation.model;

import java.util.List;
import nl.inholland.layers.model.Consultant;


public class ConsultantPresenter extends BasePresenter
{

    public Consultant present(Consultant consultant)
    {
        return consultant;
    }

    public List<Consultant> present(List<Consultant> consultants) {
       return consultants;
    }

}
