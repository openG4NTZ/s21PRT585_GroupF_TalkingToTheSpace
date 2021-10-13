﻿using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Reply;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private IReply_Service _Reply_Service;

        public ReplyController(IReply_Service Reply_Service)
        {
            _Reply_Service = Reply_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddReply(Reply_Pass_Object reply)
        {
            var result = await _Reply_Service.AddReply(reply.reply_content, reply.reply_status, reply.reply_sent_date, reply.user_id, reply.message_id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllReplys()
        {
            var result = await _Reply_Service.GetAllReplys();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateReply(Reply_Pass_Object reply)
        {
            var result = await _Reply_Service.UpdateReply(reply.reply_id, reply.reply_content, reply.reply_status, reply.reply_modified_date, reply.reply_sent_date, reply.user_id, reply.message_id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteReply(Reply_Pass_Object reply)
        {
            var result = await _Reply_Service.DeleteReply(reply.reply_id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

    }
}
