import { useEffect } from "react";
import { observer } from "mobx-react-lite";
import { Button, styled, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";
import vehicleListStore from "../stores/vehicleListStore";
import { deleteVehicleMake } from "../services/vehicleMakeService";

const Root = styled("div")(() => ({
  display: "flex",
  flexDirection: "column",
  gap: "1rem",
  width: "34.75rem",
}));

const ListContainer = styled("div")(() => ({
  backgroundColor: "#092E49",
  color: "#fff",
  display: "flex",
  justifyContent: "space-between",
  alignItems: "center",
  padding: "0.625rem 0.75rem",
  borderRadius: "0.5rem",
}));

const ButtonContainer = styled("div")(() => ({
  display: "flex",
  gap: "0.5rem",
}));

const PagingContainer = styled("div")(() => ({
  display: "flex",
  justifyContent: "center",
  gap: "1.5rem",
}));

const VehicleMakeList = () => {
  const navigate = useNavigate();
  const { vehicleMakes, page, totalPages, loading, setPage, loadVehicleMakes } =
    vehicleListStore;

  useEffect(() => {
    loadVehicleMakes();
  }, [page]);

  if (loading) return <p>Loading...</p>;

  return (
    <Root>
      {vehicleMakes.map((make) => (
        <ListContainer key={make.id}>
          <Typography>
            {make.name} - {make.abrv.toUpperCase()}
          </Typography>
          <ButtonContainer>
            <Button
              sx={{
                backgroundColor: "#275B80",
                color: "#fff",
                fontSize: "0.75rem",
                fontWeight: "500",
                letterSpacing: "5%",
                lineHeight: "1rem",
                textTransform: "capitalize",
                padding: "0.5rem 0.75rem",
                borderRadius: "0.5rem",
                "&:hover": { backgroundColor: "#5798C7" },
                "&:active": { backgroundColor: "#7DAFD3" },
              }}
              onClick={() => navigate(`/edit/${make.id}`)}
            >
              Edit
            </Button>
            <Button
              sx={{
                backgroundColor: "#275B80",
                color: "#fff",
                fontSize: "0.75rem",
                fontWeight: "500",
                letterSpacing: "5%",
                lineHeight: "1rem",
                textTransform: "capitalize",
                padding: "0.5rem 0.75rem",
                borderRadius: "0.5rem",
                "&:hover": { backgroundColor: "#5798C7" },
                "&:active": { backgroundColor: "#7DAFD3" },
              }}
              onClick={async () => {
                await deleteVehicleMake(make.id);
                await loadVehicleMakes();
              }}
            >
              Delete
            </Button>
          </ButtonContainer>
        </ListContainer>
      ))}
      <PagingContainer style={{ marginTop: "1rem" }}>
        <Button
          onClick={() => setPage(page - 1)}
          disabled={page === 1}
          sx={{
            backgroundColor: "#275B80",
            color: "#fff",
            fontSize: "0.75rem",
            fontWeight: "500",
            letterSpacing: "5%",
            lineHeight: "1rem",
            textTransform: "capitalize",
            padding: "0.5rem 0.75rem",
            borderRadius: "0.5rem",
            "&:hover": { backgroundColor: "#5798C7" },
            "&:active": { backgroundColor: "#7DAFD3" },
            "&.Mui-disabled": {
              backgroundColor: "rgba(39, 91, 128, 0.3)",
              color: "rgba(255, 255, 255, 0.3)",
            },
          }}
        >
          Previous
        </Button>
        <Typography sx={{ color: "#fff" }}>
          {totalPages === 0 ? "Page 0 of 0" : `Page ${page} of ${totalPages}`}
        </Typography>
        <Button
          onClick={() => setPage(page + 1)}
          disabled={page === totalPages || totalPages === 0}
          sx={{
            backgroundColor: "#275B80",
            color: "#fff",
            fontSize: "0.75rem",
            fontWeight: "500",
            letterSpacing: "5%",
            lineHeight: "1rem",
            textTransform: "capitalize",
            padding: "0.5rem 0.75rem",
            borderRadius: "0.5rem",
            "&:hover": { backgroundColor: "#5798C7" },
            "&:active": { backgroundColor: "#7DAFD3" },
            "&.Mui-disabled": {
              backgroundColor: "rgba(39, 91, 128, 0.3)",
              color: "rgba(255, 255, 255, 0.3)",
            },
          }}
        >
          Next
        </Button>
      </PagingContainer>
    </Root>
  );
};

export default observer(VehicleMakeList);
