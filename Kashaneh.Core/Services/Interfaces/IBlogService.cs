using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Kashaneh.DataLayer.Entities.Blog;

namespace Kashaneh.Core.Services.Interfaces
{
    public interface IBlogService
    {
        #region blog

       // IEnumerable<BlogViewModel> GetAllBlogs(int take = 0, int pageId = 1);
        Blog GetBlogById(int blogId);
        bool InsertBlog(Blog blog);
        bool UpdateBlog(Blog blog);
        void DeleteBlog(Blog blog);
        int BlogCount();
        void Save();

        #endregion

        #region blogcomment

        List<BlogComment> GetAllBlogComments();
        Blog GetBlogCommentById(int blogCommentId);
        bool InsertBlogComment(BlogComment blog);
        bool UpdateBlogComment(BlogComment blog);
        void DeleteBlogComment(BlogComment blog);


        #endregion
    }
}
