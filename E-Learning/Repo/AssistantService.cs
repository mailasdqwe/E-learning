using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Learning.Repo
{
    public class AssistantService
    {
        /// <summary>
        /// Gets all assistants.
        /// </summary>
        /// <returns>list of assistants</returns>
        public List<Assistant> GetAllAssistants()
        {
            using (var context = new DB_ELearningEntities())
            {
                var list = context.Assistants.ToList();
                return list;
            }
        }


        /// <summary>
        /// Gets the assistant by identifier.
        /// </summary>
        /// <param name="assistantID">The assistant identifier.</param>
        /// <returns>assistant with given id</returns>
        /// <exception cref="Exception">Assistant with this id not found!</exception>
        public Assistant GetAssistantById(int assistantID)
        {
            using (var context = new DB_ELearningEntities())
            {
                var assistantToGet = context.Assistants.Where(assistant => assistant.AssistantID == assistantID).FirstOrDefault();
                if (assistantToGet != null)
                    return assistantToGet;          

                else throw new Exception("Assistant with this id not found!");
            }
           
        }

        /// <summary>
        /// Deletes the assistant.
        /// </summary>
        /// <param name="assistantID">The assistant identifier.</param>
        /// <exception cref="NullReferenceException">Assistant with this id not found!</exception>
        public void DeleteAssistant(int assistantID)
        {
            using (var context = new DB_ELearningEntities())
            {
                var assistantToDelete = context.Assistants.Where(assistant => assistant.AssistantID == assistantID).FirstOrDefault();
                if (assistantToDelete != null)
                {
                    context.Assistants.Remove(assistantToDelete);
                    context.SaveChanges();
                }
                else throw new NullReferenceException("Assistant with this id not found!");
            }
        }


        /// <summary>
        /// Adds the assistant.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        public void AddAssistant(string firstName, string lastName, string email)
        {
            using (var context = new DB_ELearningEntities())
            {
                var newAssistant = context.Assistants.Create();
                newAssistant.Email = email;
                newAssistant.FirstName = firstName;
                newAssistant.LastName = lastName;

                context.Assistants.Attach(newAssistant);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Edits the assistant.
        /// </summary>
        /// <param name="assistantID">The assistant identifier.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="email">The email.</param>
        /// <exception cref="NullReferenceException">Assistant with this id not found!</exception>
        public void EditAssistant(int assistantID, string firstName, string lastName, string email) 
        {
            using (var context = new DB_ELearningEntities())
            {
                var assistantToEdit = context.Assistants.Where(assistant => assistant.AssistantID == assistantID).FirstOrDefault();
                if (assistantToEdit != null)
                {
                    assistantToEdit.Email = email;
                    assistantToEdit.FirstName = firstName;
                    assistantToEdit.LastName = lastName;

                    context.SaveChanges();
                }
                else throw new NullReferenceException("Assistant with this id not found!");
            }      
        }
    }
}