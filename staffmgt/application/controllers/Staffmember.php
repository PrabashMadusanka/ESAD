<?php
defined('BASEPATH') OR exit('No direct script access allowed');

class Staffmember extends CI_Controller {

	function __construct() {
		parent::__construct();
		
	}


	// Adding staff member
	public function addStaffMember()
	{
		$post_data = json_decode( file_get_contents('php://input') );

		$staffMemberobj = [
			'StaffName' => $post_data->StaffName,
			'EmpNo' => $post_data->EmpNo,
			'JoinDate' => $post_data->JoinDate,
			'Dob'=>  $post_data->Dob,
			'Emailaddress'=> $post_data->Emailaddress,
			'Address'=> $post_data->Address,
			'Isdeleted'=> $post_data->Isdeleted,
			'IsActive'=> $post_data->IsActive,
			'LogInfo'=> $post_data->LogInfo,
			'LibraryId'=> $post_data->LibraryId,
			'DesignationID'=> $post_data->DesignationID
		];

		$this->db->insert('StaffMember', $staffMemberobj);
		$report = $this->db->error();
		if ($msg['code'] == 0) {
			$result = [
				'code' => 200,
				'message' => 'Data Successfully Added!'
			];
		} else {
			$result = [
				'code' => $report['error'],
				'message' => $report['message']
			];
		}

		echo json_encode($result);
	}
	
	
	// Adding Designation 
	public function addDesignation()
	{
		$post_data = json_decode( file_get_contents('php://input') );

		$designationobj = [
			'DesignationID'=> $post_data->DesignationID,
			'DesignationName' => $post_data->DesignationName,
			'Isdeleted' => $post_data->Isdeleted,
			'IsActive' => $post_data->IsActive,
			'LogInfo' => $post_data->LogInfo
			//'ddate' => date('Y-m-d H:i:s')
		];

		$this->db->insert('Designation', $designationobj);
		$report = $this->db->error();
		if ($report['code'] == 0) {
			$result = [
				'code' => 200,
				'message' => 'Data Successfully Added!'
			];
		} else {
			$result = [
				'code' => $report['error'],
				'message' => $report['message']
			];
		}

		echo json_encode($result);
	}

	// Update staff member
	public function updateStaffMember()
	{
		$post_data = json_decode( file_get_contents('php://input') );

		$id = $post_data->StaffID;

		$data = [
			'StaffName' => $post_data->StaffName,
			'EmpNo' => $post_data->EmpNo,
			'JoinDate' => $post_data->JoinDate,
			'Dob'=>  $post_data->Dob,
			'Emailaddress'=> $post_data->Emailaddress,
			'Address'=> $post_data->Address,
			'Isdeleted'=> $post_data->Isdeleted,
			'IsActive'=> $post_data->IsActive,
			'LogInfo'=> $post_data->LogInfo,
			'LibraryId'=> $post_data->LibraryId,
			'DesignationID'=> $post_data->DesignationID
		];

		
		$this->db->where('StaffID', $id);
		$this->db->update('StaffMember', $data);
		$report = $this->db->error();

		if ($report['code'] == 0) {
			$result = [
				'code' => 200,
				'message' => 'Data Successfully Updated!'
			];
		} else {
			$result = [
				'code' => $report['error'],
				'message' => $report['message']
			];
		}

		echo json_encode($result);
	}


	// Select StaffMember
	public function selectAllStaffMember()
	{
		$this->db->where('Isdeleted',0);
		$data = $query = $this->db->get('StaffMember');
		echo json_encode($query->result());
	}

	// Select Designation
	public function selectAllDesignation()
	{
		$this->db->where('Isdeleted',0);
		$query = $this->db->get('Designation');
		echo json_encode($query->result());
	}

	// Delete StaffMember
	public function deleteStaffMember()
	{
		$post_data = json_decode( file_get_contents('php://input') );

		$this->db->where('StaffID',$post_data->StaffID);
		$this->db->delete('StaffMember');
		$report = $this->db->error();
		if ($report['code'] == 0) {
			$result = [
				'code' => 200,
				'message' => 'Data Successfully Deleted!'
			];
		} else {
			$result = [
				'code' => $report['error'],
				'message' => $report['message']
			];
		}

		echo json_encode($result);
	}
}
