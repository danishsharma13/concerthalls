using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using F2022A1DS.Models;

namespace F2022A1DS.Controllers
{
    public class VenuesController : Controller
    {
        // Reference to a manager object
        private Manager m = new Manager();

        // GET: Venues
        public ActionResult Index()
        {
            return View(m.VenueGetAll());
        }

        // GET: Venues/Details/5
        public ActionResult Details(int? id)
        {
            // Try to find Venue object by id
            var venueObject = m.VenueGetById(id.GetValueOrDefault());
            if (venueObject != null)
                return View(venueObject);
            
            return HttpNotFound();
        }

        // GET: Venues/Create
        public ActionResult Create()
        {
            return View(new VenueAddViewModel());
        }

        // POST: Venues/Create
        [HttpPost]
        public ActionResult Create(VenueAddViewModel addVenue)
        {
            if (!ModelState.IsValid)
                return View(addVenue);

            try
            {
                var addVenueItem = m.VenueAdd(addVenue);

                if (addVenueItem == null)
                    return View(addVenue);
                else
                    return RedirectToAction("Details", new { id = addVenueItem.VenueId });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Venues/Edit/5
        public ActionResult Edit(int? id)
        {
            // Attempt to fetch the matching object
            var venueObject = m.VenuesGetById(id.GetValueOrDefault());
            if (venueObject == null)
                return HttpNotFound();
            else
            {
                var formObject = m.mapper.Map<VenueBaseViewModel, VenueEditFormViewModel>(venueObject);
                return View(formObject);
            }
        }

        // POST: Venues/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, VenueEditViewModel venueEdit)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Edit", new { id = venueEdit.VenueId });
                }
                if (id.GetValueOrDefault() != venueEdit.VenueId)
                {
                    return RedirectToAction("Index");
                }
                
                var editVenueItem = m.VenueEdit(venueEdit);
                if (editVenueItem == null)
                {
                    return RedirectToAction("Edit", new { id = venueEdit.VenueId });
                }
                else
                {
                    return RedirectToAction("Details", new { id = venueEdit.VenueId });
                }
            }
            catch
            {
                return HttpNotFound();
            }
        }

        // GET: Venues/Delete/5
        public ActionResult Delete(int? id)
        {
            var deleteVenueItem = m.VenueGetById(id.GetValueOrDefault());
            if (deleteVenueItem == null)
            {
                return RedirectToAction("Index");
            }
            else
                return View(deleteVenueItem);
        }

        // POST: Venues/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.VenueDelete(id.GetValueOrDefault());
            return RedirectToAction("Index");
        }
    }
}
