using CarRental.Contexts;
using CarRental.Dtos.Comment;
using CarRental.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace CarRental.Repositores
{
    public class CommentRepository
    {
        AppDbContext context;

        public CommentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<CatalogComment> GetComments()
        {
            return context.CatalogComments.ToList();
        }

        public CatalogComment GetComment(int id)
        {
            return context.CatalogComments.Where(x => x.ID == id).FirstOrDefault();
        }

        public bool AddComment(CreateCommentDto comment) 
        {
            if (comment.Content != null)
            {
                Catalog catalog = context.Catalogs.Where(x => x.ID == comment.CatalogId).FirstOrDefault();
                if (catalog != null)
                {
                    CatalogComment comment1 = new CatalogComment();
                    comment1.Content = comment.Content;
                    comment1.CatalogId = comment.CatalogId;
                    comment1.Catalog = catalog;
                    context.CatalogComments.Add(comment1);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool DeleteComment(int id)
        {
            CatalogComment comment = GetComment(id);
            if (comment != null)
            {
                context.CatalogComments.Remove(comment);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateComment(int id,CatalogComment comment)
        {
            CatalogComment dbComment = GetComment(id);
            if (dbComment != null)
            {
                dbComment.Content = comment.Content;
                context.CatalogComments.Update(dbComment);
                context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
