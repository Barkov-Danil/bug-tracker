package com.bugtracker.bug_tracker_api.deadline_change_request.domain;

import jakarta.persistence.*;
import lombok.Data;
import com.bugtracker.bug_tracker_api.ticket.domain.Ticket;
import com.bugtracker.bug_tracker_api.user.domain.User;

import java.time.OffsetDateTime;
import java.time.ZoneOffset;
import java.util.UUID;

@Entity
@Table(name = "deadline_change_requests")
@Data
public class DeadlineChangeRequest {
    @Id
    @GeneratedValue(strategy = GenerationType.UUID)
    private UUID id;

    @Column(nullable = false)
    private OffsetDateTime requestedDeadline;

    @Column(nullable = false)
    private String reason;

    @Enumerated(EnumType.STRING)
    @Column(nullable = false)
    private DeadlineRequestStatus status = DeadlineRequestStatus.Pending;

    @Column(nullable = false)
    private OffsetDateTime createdAt = OffsetDateTime.now(ZoneOffset.UTC);

    @ManyToOne(optional = false)
    @JoinColumn(name = "ticket_id", nullable = false)
    private Ticket ticket;

    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @JoinColumn(name = "requested_by_id", nullable = false)
    private User author;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "reviewer_id")
    private User reviewer;
}
