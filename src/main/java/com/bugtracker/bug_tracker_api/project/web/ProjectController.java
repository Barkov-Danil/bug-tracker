package com.bugtracker.bug_tracker_api.project.web;

import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import com.bugtracker.bug_tracker_api.project.services.ProjectService;
import com.bugtracker.bug_tracker_api.project.web.dto.ProjectResponse;

import java.util.List;
import java.util.UUID;

@RestController
@RequestMapping("/api/projects")
@RequiredArgsConstructor
public class ProjectController {

    private final ProjectService projectService;

    @GetMapping
    public List<ProjectResponse> getUserProjects(@RequestParam UUID userId) {
        return projectService.getUserProjects(userId);
    }
}
