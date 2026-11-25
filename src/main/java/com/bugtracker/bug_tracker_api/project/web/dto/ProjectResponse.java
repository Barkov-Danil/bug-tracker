package com.bugtracker.bug_tracker_api.project.web.dto;

import java.time.OffsetDateTime;
import java.util.UUID;

public record ProjectResponse(
    UUID id,
    String name,
    String description,
    String linkToRepo,
    OffsetDateTime createdAt
) {}
