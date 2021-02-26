using System;
using System.Collections.Generic;
using System.Text;

namespace UserProfileDemo
{
    public class ViewModel
    {
        public ViewModel()
        {

            Onboardings = Getonboarging();
        }

        public List<Onboarding> Onboardings { get; set; }
        private List<Onboarding> Getonboarging()
        {
            return new List<Onboarding>
            {
                new Onboarding{ Heading="About IWORKTECH" ,caption="At iWork Technologies our mission is to help our customers, clients and partners build software apps and services better, faster and at a considerably lower cost."},
                new Onboarding{ Heading="Customer Focus" ,caption="We have invested in developing our best practices around customer focus to ensure we deliver on time, within budget and with consistent quality every time. "},
                new Onboarding{ Heading="Engagement Models" ,caption="Our engagement models are flexible and malleable to our client's needs and fit. With the ability to scale up and down it reduces their risk and exposure."}
            };
        }

    }
    public class Onboarding
    {
        public string Heading { get; set; }
        public string caption { get; set; }

    }
}
