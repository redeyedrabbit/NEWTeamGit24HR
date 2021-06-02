﻿using _24hr.Data;
using _24hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _24hr.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }
        // Create Post
        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                AuthorId = _userId,
                Title = model.Title,
                Text = model.Text
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        // Get All Posts 
        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Posts.Where(e => e.AuthorId == _userId)
                    .Select(e => new PostListItem
                    {
                        PostId = e.PostId,
                        Title = e.Title,
                        Text = e.Text
                    }
                    );
                return query.ToArray();
            }
        }

        // Get Posts by Author Id
        public PostDetail GetPostByAuthorId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Posts.Single(e => e.PostId == id && e.AuthorId == _userId);
                return new PostDetail
                {
                    PostId = entity.PostId,
                    Title = entity.Title,
                    Text = entity.Text
                };
            }
        }

        // Update Post
        public bool UpdatePost(PostUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(e => e.PostId == model.PostId && e.AuthorId == _userId);
                entity.Title = model.Title;
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete Post
        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Posts
                    .Single(e => e.PostId == postId && e.AuthorId == _userId);
                ctx.Posts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
