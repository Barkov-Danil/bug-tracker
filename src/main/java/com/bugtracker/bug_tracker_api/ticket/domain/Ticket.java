package com.bugtracker.bug_tracker_api.ticket.domain;

import com.bugtracker.bug_tracker_api.comment.domain.Comment;
import com.bugtracker.bug_tracker_api.deadline_change_request.domain.DeadlineChangeRequest;
import com.bugtracker.bug_tracker_api.fix.domain.Fix;
import jakarta.persistence.*;
import lombok.Data;
import com.bugtracker.bug_tracker_api.notification.domain.Notification;
import com.bugtracker.bug_tracker_api.project.domain.Project;
import com.bugtracker.bug_tracker_api.user.domain.User;

import java.time.OffsetDateTime;
import java.time.ZoneOffset;
import java.util.HashSet;
import java.util.List;
import java.util.Set;
import java.util.UUID;

@Entity
@Table(name = "tickets")
@Data
public class Ticket {
    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    private UUID id;

    @Column(nullable = false)
    private String title;

    @Column(nullable = false)
    private String description;

    @Enumerated(EnumType.STRING)
    @Column(nullable = false)
    private TicketStatus status = TicketStatus.Free;

    @Enumerated(EnumType.STRING)
    @Column(nullable = false)
    private TicketPriority priority = TicketPriority.Mid;

    @Column(nullable = false)
    private OffsetDateTime createdAt = OffsetDateTime.now(ZoneOffset.UTC);

    private OffsetDateTime closedAt;

    @Column(nullable = false)
    private OffsetDateTime deadline;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "project_id", nullable = false)
    private Project project;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "author_id", nullable = false)
    private User author;

    @ManyToMany
    @JoinTable(
            name = "ticket_developers",
            joinColumns = @JoinColumn(name = "ticket_id"),
            inverseJoinColumns = @JoinColumn(name = "user_id")
    )
    private Set<User> developers = new HashSet<>();

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "closed_by_id")
    private User closedBy;

    @OneToMany(mappedBy = "ticket", cascade = CascadeType.ALL)
    private List<Fix> fixes;

    @OneToMany(mappedBy = "ticket", cascade = CascadeType.ALL)
    private List<DeadlineChangeRequest> deadlineChangeRequests;

    @OneToMany(mappedBy = "ticket", cascade = CascadeType.ALL, orphanRemoval = true)
    private List<Comment> comments;

    @OneToMany(mappedBy = "ticket", cascade = CascadeType.ALL)
    private List<Notification> notifications;
}