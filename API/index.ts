// Imports
import * as express from "express";
import { Request, Response } from "express";
import { uptime } from "process";
import * as mongoose from "mongoose";
import { rateLimit } from 'express-rate-limit';
import * as fs from "fs";

const app: express.Express = express.default();

const limiter = rateLimit({
    windowMs: 60 * 1000, // 1 minute
    limit: 1200,
    standardHeaders: 'draft-7',
    legacyHeaders: false,
    message: async (req: Request, res: Response) => {
        res.jsonp({ success: false, error: "RATELIMIT_EXCEEDED", message: "Ratelimit exceeded" });
    }
});

app.use(limiter);

if(!fs.existsSync("config.json")) {
    throw "No config file found";
}

const config = require("../config.json");

// Server connection
const server = config.mongodb.server;
const database = config.mongodb.database;

mongoose.connect(`mongodb://${server}/${database}`)
    .then(() => {
        console.log('MongoDB connected!')
    })
    .catch(err => {
        console.log('Failed to connect to MongoDB', err)
    });

// Imports
import {  } from "./schemas";
import { generateRandomString, uptimeToHuman } from "./utils";

// Mongoose models

// API routes
app.get("/", (req: Request, res: Response) => {
    res.jsonp({
        status: "online",
        version : "1.0.0",
        uptime : uptime(),
        uptime_human: uptimeToHuman(uptime()),
        time: new Date(),
        rate_limits: {
            requests_per_minute: 1200,
            requests_per_second: 20,
            current_usage: (req as any).rateLimit.used
        },
        ip: req.ip,
        ips: req.ips,
        success: true
    });
});

// Listening
app.listen(config.port);