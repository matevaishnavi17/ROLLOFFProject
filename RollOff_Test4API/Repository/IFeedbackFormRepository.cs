using RollOff_Test4API.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOff_Test4API.Repository
{
    public interface IFeedbackFormRepository
    {
        Task<FeedbackForm> AddFormAsync(FeedbackForm formTable);

        Task<IEnumerable<FeedbackForm>> GetAllFormsAsync();

        Task<FeedbackForm> DeleteFormAsync(double ggid);

        Task<FeedbackForm> UdateFormAsync(double ggid, FeedbackForm form);
    }
}
