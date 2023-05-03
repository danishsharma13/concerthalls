using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using F2022A1DS.Data;
using F2022A1DS.Models;

// ************************************************************************************
// WEB524 Project Template V1 == 2227-d4f5947b-eb5c-428a-afb6-543142144f01
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace F2022A1DS.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();

                cfg.CreateMap<Venue, VenueBaseViewModel>();

                cfg.CreateMap<VenueAddViewModel, Venue>();

                cfg.CreateMap<VenueBaseViewModel, VenueEditFormViewModel>();

            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().

        public IEnumerable<VenueBaseViewModel> VenueGetAll()
        {
            // Create a variable to query Venue items from the database in Company ascending order
            var orderedVenuesList = from ovl in ds.Venues
                                    orderby ovl.Company
                                    select ovl;

            return mapper.Map<IEnumerable<Venue>, IEnumerable<VenueBaseViewModel>>(orderedVenuesList);
        }

        public VenueBaseViewModel VenuesGetById(int? id)
        {
            // Try to find the venue by id
            var venueObject = ds.Venues.Find(id.GetValueOrDefault());

            // If the venueObject is found then return the mapper with venueObject
            // If not then return null
            return venueObject == null ? null : mapper.Map<Venue, VenueBaseViewModel>(venueObject);

        }

        public VenueBaseViewModel VenueAdd(VenueAddViewModel addVenue)
        {
            // Add the parameter object to the database by using mapper
            var addVenueItem = ds.Venues.Add(mapper.Map<VenueAddViewModel, Venue>(addVenue));

            // Save changes to the database
            ds.SaveChanges();

            // If the venueObject is added then return the mapper with venueObject
            // If not then return null
            return addVenueItem == null ? null : mapper.Map<Venue, VenueBaseViewModel>(addVenueItem);
        }

        public VenueBaseViewModel VenueEdit(VenueEditViewModel venue)
        {
            // Try to find the venue by id
            var venueObject = ds.Venues.Find(venue.VenueId);

            // If venue is found then set the parameter venue object values in the database with the same venueId
            if (venueObject != null)
            {

                ds.Entry(venueObject).CurrentValues.SetValues(venue);

                // Save changes to the database
                ds.SaveChanges();

                // Return a mapper of venueObject
                return mapper.Map<Venue, VenueBaseViewModel>(venueObject);

            }

            // If Venue was not found then return null.
            return null; 
        }

        public bool VenueDelete(int id)
        {
            // Try to find the venue by id
            var deleteVenueItem = ds.Venues.Find(id);

            // If deleteVenueItem is not null then we have found the object in the database
            if (deleteVenueItem != null)
            {
                // Delete the venue object from the database
                ds.Venues.Remove(deleteVenueItem);
                // Then save changes to the database
                ds.SaveChanges();
                // Successfull deletion will return true
                return true;
            }

            // Nonsuccessfull deletion will return false
            return false;
        }

        internal object VenueGetById(object p)
        {
            throw new NotImplementedException();
        }
    }
}